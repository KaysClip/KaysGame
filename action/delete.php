<?php
require '../config.php';
require '../database.php';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Check if the required data (int_id) is provided in the POST request
    if (isset($_POST['int_id'])) {
        $intid = $_POST['int_id'];

        // Create a database connection using mysqli
        $conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

        if ($conn->connect_error) {
            $response = array("message" => "Database connection failed");
            echo json_encode($response);
        } else {
            $stmt = $conn->prepare("DELETE FROM interactables WHERE int_id = ?");
            $stmt->bind_param("i", $intid);

            if ($stmt->execute()) {
                $response = array("message" => "Record deleted successfully");
                echo json_encode($response);
            } else {
                $response = array("message" => "Error deleting record: " . $conn->error);
                echo json_encode($response);
            }

            $stmt->close();
            $conn->close();
        }
    } else {
        $response = array("message" => "Missing required data");
        echo json_encode($response);
    }
} else {
    header("HTTP/1.0 405 Method Not Allowed");
    echo "Method not allowed";
}
?>
