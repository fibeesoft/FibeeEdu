<?php
include_once 'dbconn.php';

$question_p = $_POST["question"];
$answer_p = $_POST["answer"];
$class_p = $_POST["class"];
$solution_p = $_POST["solution"];


$stmt = $conn->prepare("INSERT INTO MathTasks (question, answer, class, solution) VALUES (?, ?, ?, ?)");
$stmt->bind_param("ssss", $question_p, $answer_p, $class_p, $solution_p);

$stmt->execute();

echo "New task added";

$stmt->close();
$conn->close();
?>
