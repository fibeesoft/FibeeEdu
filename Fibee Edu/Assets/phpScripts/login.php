<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$password_p = $_POST["password"];

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

