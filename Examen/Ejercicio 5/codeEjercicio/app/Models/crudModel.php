<?php
namespace App\Models;
use CodeIgniter\Model;

class crudModel extends Model{
    
    public function listarCuenta(){
        $sql="select * from cuenta;";
        $query=$this->db->query($sql);
        $result=$query->getResult();
        if(count($result)>=1){
            return $result;
        }else{
            return NULL;
        }
    }
    public function eliminarCuenta($data){
        $sql = "DELETE FROM cuenta WHERE id = ?";
        $query = $this->db->query($sql, array($data));
        return $query; // Devuelve el número de filas afectadas por la operación DELETE
    }
}
?>