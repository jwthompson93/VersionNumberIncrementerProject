# Version Number Incrementer

This application is designed to accept a Version Number from a location (Currently only accepts files) and increment the version number based on the type of release.

## Parameters
>
>  --release_type                Required. Determines the release type to be incremented (Major | Minor)
>
>  --version_number_file         Required. THe file path for the Version Number file
>
>  --major_release_position      (Default: 3) Determines where the major version number is positioned in the Version
>                                Number
>
>  --minor_release_position      (Default: 4) Determines where the minor version number is positioned in the Version
>                                Number
>
>  --version_number_separator    (Default: .) The character that separates the numbers in the Version Number
>
>  --help                        Display this help screen.
>
>  --version                     Display version information.