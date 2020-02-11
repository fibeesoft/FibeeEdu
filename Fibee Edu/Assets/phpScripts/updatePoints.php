
<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$points_p = $_POST["points"];

$stmt = $conn->prepare("UPDATE Users SET points = ? WHERE username = ?");
$stmt->bind_param("is", $points_p, $username_p);

$stmt->execute();

echo "Points updated";

$stmt->close();
$conn->close();
?>
