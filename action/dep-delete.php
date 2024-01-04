<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php';

// Check if ID is sent through POST request
if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['id'])) {
    $id = $_POST['id'];

    $conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    // Prepare and bind the DELETE statement
    $stmt = $conn->prepare("DELETE FROM buildings WHERE id = ?");
    $stmt->bind_param("i", $id);

    if ($stmt->execute()) {
        // Deletion successful
        echo json_encode(['success' => true]);
    } else {
        // Error in deletion
        echo json_encode(['success' => false, 'error' => $stmt->error]);
    }

    $stmt->close();
    $conn->close();
} else {
    // If ID is not received through POST request
    echo json_encode(['success' => false, 'error' => 'No ID received']);
}
?>
