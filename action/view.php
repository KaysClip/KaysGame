<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php'; // Corrected path for including database.php


// Create a database connection using mysqli
$conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if(isset($_GET['id'])){
    $WHERE=" WHERE int_id=".$_GET['id'];
}else{
    $WHERE="WHERE status = 0";
}

$sql = "SELECT * FROM interactables ".$WHERE;
$result = $conn->query($sql);

if (!$result) {
    die("Query failed: " . $conn->error);
}

if ($result->num_rows > 0) {
   // echo "<table>";
    while ($row = $result->fetch_assoc()) {
        
        echo "<tr data-id='" . $row["int_id"] . "'>
                <td>" . $row['int_id'] . "</td>
                <td>" . $row["location"] . "</td>
                <td>" . implode(' ', array_slice(explode(' ', $row['int_desc']), 0, 20)) . "
                </td>                
                <td>" . $row['int_position'] . "</td>
                <td>" . $row['building_id'] . "</td>
                <td>
                <div class='button-container dropdown'>
                <button class='btn btn-link' type='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>
                    <i class='bi bi-list' style='color: #000; font-size: 18px;'></i>
                </button>
                <div class='dropdown-menu' aria-labelledby='dropdownMenuButton'>
                    <button intBuild1='".$row['building_id']."' intDesc1='".$row['int_desc']."' intPos1='".$row['int_position']."' intLoc1='".$row['location']."' type='button' data-interactableid='" . $row['int_id'] . "' class='dropdown-item edit'>
                        <i class='bi bi-pencil-square' style='color: #4CAF50;'></i> Edit Interactable
                    </button>
                    <button  intBuild1='".$row['building_id']."' intDesc1='".$row['int_desc']."' intPos1='".$row['int_position']."' intLoc1='".$row['location']."' type='button' data-interactableid='" . $row['int_id'] . "' class='dropdown-item info'>
                        <i class='bi bi-info-circle' style='color: #2196F3;'></i> View Info
                    </button>
                    <button type='button' data-interactableid='" . $row['int_id'] . "' class='dropdown-item delete'>
                        <i class='bi bi-trash' style='color: #F44336;'></i> Delete Interactable
                    </button>
                    
                </div>
            </div>
            
                </td>
              </tr>";
            
              
              
    }
   // echo '</table>';
}
$conn->close();
?>
