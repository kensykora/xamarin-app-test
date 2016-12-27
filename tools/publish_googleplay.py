#!/usr/bin/python
#
# Copyright 2014 Google Inc. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

# Samples: https://github.com/googlesamples/android-play-publisher-api/tree/master/v2/python
#
# Expects key.p12 - This is not added to version control. The nuget package
# 'secure-file' is used to encrypt / decrypt and the decryption key IS
# stored in appveyor.

"""Lists all the apks for a given app."""

import os
import argparse
import mimetypes

from apiclient.discovery import build
import httplib2
from oauth2client.service_account import ServiceAccountCredentials
from oauth2client import client


SERVICE_ACCOUNT_EMAIL = (
    '794410170321-compute@developer.gserviceaccount.com')

# Declare command-line flags.
argparser = argparse.ArgumentParser(add_help=False)
argparser.add_argument('package_name',
                       help='The package name. Example: com.android.sample')
argparser.add_argument('apk_file',
                       nargs='?',
                       default='test.apk',
                       help='The path to the APK file to upload.')

def main():
  # Load the key in PKCS 12 format that you downloaded from the Google APIs
  # Console when you created your Service account.
  scope = 'https://www.googleapis.com/auth/androidpublisher'
  # Create an httplib2.Http object to handle our HTTP requests and authorize it
  # with the Credentials. Note that the first parameter, service_account_name,
  # is the Email address created for the Service account. It must be the email
  # address associated with the key that was created.

  credentials = ServiceAccountCredentials.from_p12_keyfile(
  	  SERVICE_ACCOUNT_EMAIL,
  	  os.getenv('APPVEYOR_BUILD_FOLDER') + '\\tools\\key.p12',
  	  scopes=[scope]
  	)

  http = httplib2.Http()
  http = credentials.authorize(http)

  service = build('androidpublisher', 'v2', http=http)

  # Process flags and read their values.
  flags = argparser.parse_args()

  package_name = flags.package_name
  apk_file = flags.apk_file

  try:
    edit_request = service.edits().insert(body={}, packageName=package_name)
    result = edit_request.execute()
    edit_id = result['id']

    apk_response = service.edits().apks().upload(
        editId=edit_id,
        packageName=package_name,
        media_body=apk_file).execute()

    print('Version code %d has been uploaded' % apk_response['versionCode'])
    mimetypes.add_type("application/vnd.android.package-archive", ".apk")

    track_response = service.edits().tracks().update(
        editId=edit_id,
        track=TRACK,
        packageName=package_name,
        body={u'versionCodes': [apk_response['versionCode']]}).execute()

    print('Track %s is set for version code(s) %s' % (
        track_response['track'], str(track_response['versionCodes'])))

    commit_request = service.edits().commit(
        editId=edit_id, packageName=package_name).execute()

    print('Edit "%s" has been committed' % (commit_request['id']))

  except client.AccessTokenRefreshError:
    print ('The credentials have been revoked or expired, please re-run the '
           'application to re-authorize')

if __name__ == '__main__':
  main()