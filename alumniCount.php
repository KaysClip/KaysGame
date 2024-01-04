<?php
include 'config.php';

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

//$id = $_GET['id'];

$sql = "SELECT COUNT(*) as count FROM alumni";
$stmt = $conn->prepare($sql);
$stmt->execute();
$result = $stmt->get_result();

if ($result) {
    $row = $result->fetch_assoc();
    $count = $row['count'];

    echo $count;
} else {
    echo "No Data Found";
}
?>
