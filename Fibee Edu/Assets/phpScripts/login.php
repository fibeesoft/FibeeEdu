<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$password_p = $_POST["password"];

//$username_p = "zaza";
//$password_p = "zaza1";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
//$conn -> set_charset('utf-8');
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}


// prepare and bind
$stmt = $conn->prepare("SELECT username,points FROM Users WHERE username = ? AND pass = ?");
$stmt->bind_param("ss", $username_p, $password_p);
$stmt->execute();

$stmt->store_result();
if($stmt->num_rows === 0) exit('No rows');
$stmt->bind_result($username, $points);
$stmt->fetch();
echo $username ."|".$points;

$stmt->close();
$conn->close();

?>

