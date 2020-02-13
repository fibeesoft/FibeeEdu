<?php

$servername = "localhost";
$dbusername = "fibee2_a";
$dbpassword = "Hasl01123@!";
$dbname = "fibee2_a";


$conn = new mysqli($servername, $dbusername, $dbpassword, $dbname);
$conn -> set_charset('utf-8');
$conn->set_charset('utf8');

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$sql = "SELECT `question`, `answer`, `class`, `solution` FROM MathTasks order by id";


$result = $conn->query($sql);

    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            echo $row["question"]."|".$row["answer"]."|".$row["class"]."|".$row["solution"].";";
        }
    } else {
        echo "0 results";
    }
    $conn->close();
?>