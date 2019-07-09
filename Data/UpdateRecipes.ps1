<#
    .SYNOPSIS
    Update Recipes from ffxivdatamining

    .DESCRIPTION
    Will download the recipes csv from ffxivdatamining Github repository,
    parse the contents and write the required json format for CarbuncleTech.
#>

$remoteUrl = "https://raw.githubusercontent.com/viion/ffxiv-datamining/master/csv/Recipe.csv"
$localFile = New-TemporaryFile

$downloader = New-Object System.Net.WebClient
$downloader.DownloadFile($remoteUrl, $localFile)

$rawRecipes = Import-Csv -Path $localFile -Delimiter ","

$recipes = @()

# Skip the first two lines because they describe the file.
# Skip the third line because it contains a null recipe.
For($i = 3; $i -le $rawRecipes.Count; $i++)
{
    # Select the job and the item id, see Godbert for correct offset
    $r = $rawRecipes[$i] | Select "1","3"

    # Make this easier to read and fix the job numbers.
    # Job numbers are calculated by 8 + offset from file.
    # This is due to the ClassJobType enum starting the
    # crafters at index 8.
    $cr = [PSCustomObject]@{
        classjob = ([int]$r.1 + 8)
        item     = [int]$r.3
    }

    $recipe += @($cr)
}

Remove-Item -Path $localFile -Force

$recipe | ConvertTo-Json -Depth 99 -Compress | Out-File -FilePath "Recipes.json"
