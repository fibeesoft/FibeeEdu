
<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$points_p = $_POST["points"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
$conn -> set_charset('utf-8');
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// prepare and bind
$stmt = $conn->prepare("UPDATE Users SET points = ? WHERE username = ?");
$stmt->bind_param("is", $points_p, $username_p);

$stmt->execute();

echo "New records created successfully";

$stmt->close();
$conn->close();
?>
