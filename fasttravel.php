<?php
include 'config.php';

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$id = $_GET['id'];

$sql = "SELECT * FROM fasttravel WHERE ft_id = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $id);
$stmt->execute();
$result = $stmt->get_result();

if ($result) {
    $data = array();

    while ($row = $result->fetch_assoc()) {
        echo $row["ft_id"] . "|" . $row["ft_name"]. "|" . $row["ft_desc"]. "|" . $row["ft_pos"]. "|";
    }
} else {
    echo "No Data Found";
}
?>