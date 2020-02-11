<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$password_p = $_POST["password"];
$email_p = $_POST["email"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// prepare and bind
$stmt = $conn->prepare("INSERT INTO Users (username, pass, email) VALUES (?, ?, ?)");
$stmt->bind_param("sss", $username_p, $password_p, $email_p);

$stmt->execute();

echo "New records created successfully";

$stmt->close();
$conn->close();
?>


<?php
//using PDO
/*
<?php
include_once 'dbconn.php';

$username_p = $_POST["username"];
$password_p = $_POST["password"];
$email_p = $_POST["email"];

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // prepare sql and bind parameters
    $stmt = $conn->prepare("INSERT INTO Users (username, pass, email)
    VALUES (:username, :pass, :email)");
    $stmt->bindParam(':username', $username_p);
    $stmt->bindParam(':pass', $password_p);
    $stmt->bindParam(':email', $email_p);
    
    $stmt->execute();


    echo "New records created successfully";
    }
catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }
$conn = null;
?>
*/
?>