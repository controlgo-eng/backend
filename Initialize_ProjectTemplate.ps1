Write-Host "Welcome to Worldsys template renamer!"
Write-Host "Type the solution name (this name will be used with the proper API, Domain, Model suffixes):"
$expectedName = Read-Host 

if($expectedName -Match "(API|Application|Domain|Infrastructure)$"){
	Write-Host "Solution name shouldn't contain the term 'API', 'Application', 'Domain', 'Infrastructure'."
	Write-Host "Renaming aborted!"
	pause
	exit
}

# Rename the affected directories
$directoriesToProcess = @($(Get-ChildItem -Path "Worldsys*" -Recurse -Directory) | % { $_.FullName })

function ReplaceInFolder($path, $name){
	# Split container directory and directory name from path
	$dirName = Split-Path $path -Leaf;
	$dirPath = Split-Path $path -Parent;
	# Update the directory name using the same pattern before
	$dirName = $dirName -Replace "World?sys\.(?!Core\.)","$name."
	$newDirPath = Join-Path $dirPath $dirName
	#Rename-Item $path $newDirPath
	git mv -f $path $newDirPath
}

ForEach ($dir In $directoriesToProcess)  { 
	ReplaceInFolder $dir $expectedName;
}

# Rename the affected csproj and sln filenames
$csProjsToProcess = @($(Get-ChildItem -Path "*.csproj" -Recurse) | % { $_.FullName })
ForEach ($csproj In $csProjsToProcess)  { 
	ReplaceInFolder $csproj $expectedName;
}

$slnFilename = (Resolve-Path "./Worldsys.sln").ToString()
ReplaceInFolder $slnFilename $expectedName;

# Searching in code files to replace namespaces
$filesToProcess = @($(Get-ChildItem -Path *.cs -Recurse -File) | % { $_.FullName })
$filesToProcess +=@($(Get-ChildItem -Path *.csproj -Recurse -File) | % { $_.FullName })
$filesToProcess +=@($(Get-ChildItem -Path *.sln -Recurse -File) | % { $_.FullName })
$filesToProcess +=@($(Get-ChildItem -Path ".github\workflows\ci-variables.yml" -Recurse -File) | % { $_.FullName })
$filesToProcess +=@($(Get-ChildItem -Path "Dockerfile" -Recurse -File) | % { $_.FullName })

function ReplaceInFile($path, $name){
	$content = Get-Content -Path $path;
	$content = $content -Replace "World?sys\.(?!Core\.)","$name."
	Set-Content -Path $path -Value $content;
}

ForEach ($file In $filesToProcess)  { 
	ReplaceInFile $file $expectedName;
}
