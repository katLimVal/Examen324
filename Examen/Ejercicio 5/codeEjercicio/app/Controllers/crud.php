<?php

namespace App\Controllers;
use App\Models\crudModel;

class crud extends BaseController
{
    public function index()
    {
        $crud=new crudModel();
        $datos=$crud->listarCuenta();
        $mensaje=session('mensaje');
        $data=[
                "datos"=> $datos,
                "mensaje"=> $mensaje
        ];
        return view('listado',$data);
    }
    public function eliminar($idcuenta){
        $crud=new crudModel();
        $data=[
            "id"=> $idcuenta
        ];
        $respuesta=$crud->eliminarCuenta($data);
        if($respuesta){
            return redirect()->to(base_url().'/')->with('mensaje','4');
        }else{
            return redirect()->to(base_url().'/')->with('mensaje','5');
        }
    }

}
