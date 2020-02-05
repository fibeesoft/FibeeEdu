<?php
$servername = "localhost";
$username = "fibee2_a";
$password = "Hasl01123@!";
$dbname = "fibee2_a";


$playerid = $_POST["_playerIdPost"];
$playerUsername =$_POST["_playerUsernamePost"];
//$playerid = 1;
//$playerUsername = "Lupi";

$db = mysqli_connect($servername, $username,$password, $dbname);
$update = "UPDATE Users SET username ='$playerUsername' WHERE id='$playerid'";
$result = mysqli_query($db,$update);
?>