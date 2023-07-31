
- upload file
- nc web:
    `                file path: v-----------------------`
  - `PUT      /remote.php/webdav/Test/test.code-workspace`
    - gets a 201
  - `PROPFIND /remote.php/webdav/Test/test.code-workspace`
    - 