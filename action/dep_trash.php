<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php';

function markBuildingAsTrashed($buildingId) {
    // Connect sa database
    $conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    // Update ang status sa building ngadto sa 'trashed'
    $stmt = $conn->prepare("UPDATE buildings SET status = 1 WHERE id = ?");
    $stmt->bind_param("i", $buildingId);
    $stmt->execute();
    
    if ($stmt->affected_rows > 0) {
        // Building gi-marka na nga trashed
        $stmt->close();
        $conn->close();
        echo "Building marked as trashed successfully"; // Echo message for debugging purposes
        return true;
    } else {
        // Dili successful ang pag-update
        $stmt->close();
        $conn->close();
        echo "Error marking building as trashed"; // Echo message for debugging purposes
        return false;
    }
}

// Check kung naay POST request gikan sa AJAX
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $buildingId = $_POST['buildingId'];

    // Tawgon ang function para ma-update ang status sa building
    markBuildingAsTrashed($buildingId);
}
?>
