# codestats
A fast CLI tool to count lines of code by file type
codestats CLI

codestats is a CLI tool for counting lines of code by file type and directory, displaying version info, and showing help.

🛠 Installation

Clone the repository

git clone https://github.com/n4sser77/codestats.git
cd codestats


Build and pack the tool

dotnet pack -c Release


The .nupkg file is created in:

./bin/Release/


Install the CLI globally from the local package

dotnet tool install --global codestats --add-source ./bin/Release --version 0.0.2-pre


If you already installed an older version, uninstall first:

dotnet tool uninstall --global codestats

📖 Usage Examples
Count lines in the current directory (default .cs files)
codestats cl

Count lines for specific file types in the current directory
codestats cl -t ts,tsx,js
codestats cl --types ts,tsx

Count lines in a specific folder
codestats cl src -t ts,tsx
codestats cl backend --types js,ts


If no folder is specified, codestats assumes the current working directory.

Show CLI version
codestats --version

Show help
codestats --help

⚡ Notes

Default file type: .cs

Skips common binary/build folders: bin/, obj/, .git/, node_modules

Supports short and long options:

cl or --countlines

-t or --types

--path or just
codestats then write the path with a space between
