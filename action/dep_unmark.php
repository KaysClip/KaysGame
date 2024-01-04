<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php';

function unmarkBuilding($buildingId) {
    $conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    $stmt = $conn->prepare("UPDATE buildings SET status = 0 WHERE id = ?");
    $stmt->bind_param("i", $buildingId);
    $stmt->execute();

    if ($stmt->error) {
        error_log("SQL Error: " . $stmt->error);
        $stmt->close();
        $conn->close();
        echo "Error marking building as retrieved";
        return false;
    } elseif ($stmt->affected_rows > 0) {
        $stmt->close();
        $conn->close();
        echo "Building retrieved successfully";
        return true;
    } else {
        $stmt->close();
        $conn->close();
        echo "No building found for ID: " . $buildingId;
        return false;
    }
}
// Handle POST request to update building status
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (isset($_POST['buildingId'])) {
        $buildingId = $_POST['buildingId'];
        // Log or echo the received ID for debugging
        error_log("Received building ID: " . $buildingId);
        unmarkBuilding($buildingId); // Uncomment this line to execute the update
    } else {
        echo "Invalid building ID";
    }
}

?>
