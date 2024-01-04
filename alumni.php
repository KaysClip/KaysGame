<?php
include 'config.php';

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
 
$id = $_GET['id'];

$sql = "SELECT * FROM alumni WHERE alumni_count = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $id);
$stmt->execute();
$result = $stmt->get_result();

if ($result) {
    $data = array();

    while ($row = $result->fetch_assoc()) {
        echo $row["alumni_id"] . "|" . $row["alumni_name"]. "|" . $row["alumni_prgrm"]. "|" . $row["alumni_year&lvl"]. "|". $row["alumni_photoname"]. "|";
    }
} else {
    echo "No Data Found";
}
?>