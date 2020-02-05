<?php
$servername = "localhost";
$username = "fibee2_a";
$password = "Hasl01123@!";
$dbname = "fibee2_a";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT id, username FROM Users";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        echo ";". $row["id"]." ".$row["username"];
    }
} else {
    echo "0 results";
}
$conn->close();

?>