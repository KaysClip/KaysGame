<?php

include 'config.php';

// Create a connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Get the ID from the request
$id = $_GET['id'];

// Use a prepared statement to prevent SQL injection
$sql = "SELECT * FROM interactables WHERE int_id = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $id);
$stmt->execute();
$result = $stmt->get_result();

if ($result) {
    $data = array();

    // Fetch the data from the result set
    while ($row = $result->fetch_assoc()) {
        echo $row["location"] . "|" . $row["int_desc"]. "|" . $row["int_position"]. "|";
    }
} else {
    echo "No Data Found";
}

?>