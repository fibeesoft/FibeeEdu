<?php
$servername = "localhost";
$dbusername = "";
$dbpassword = "";
$dbname = "";

$conn = new mysqli($servername, $dbusername, $dbpassword, $dbname);
$conn -> set_charset('utf-8');

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}


?>