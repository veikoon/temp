 <?php
$myfile = fopen("index.php", "r") or die("Unable to open file!");
echo base64_encode(fread($myfile,filesize("index.php")));
fclose($myfile);
?> 
