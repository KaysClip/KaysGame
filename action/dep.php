<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php';
$conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $response = array();
    $sql = "SELECT id, name FROM buildings";
    $result = $conn->query($sql);
    if ($result) {
        if ($result->num_rows > 0) {
            $departments = array();
            while ($row = $result->fetch_assoc()) {
                $departments[] = array(
                    'id' => $row['id'],
                    'name' => $row['name']
                );
            }
            $response['status'] = 1;
            $response['departments'] = $departments;
        } else {
            $response['status'] = 0;
            $response['message'] = 'No departments found';
        }
    } else {
        $response['status'] = 0;
        $response['message'] = 'Failed to fetch departments: ' . $conn->error;
    }
    header('Content-Type: application/json');
    echo json_encode($response);
} else {
    $response['status'] = 0;
    $response['message'] = 'Invalid request method';
    echo json_encode($response);
}
$conn->close();
