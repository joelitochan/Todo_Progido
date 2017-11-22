﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.BO;
using Proyecto.DAO;
using System.IO;


namespace Proyecto.Controllers
{
    public class todo_proController : Controller
    {
        // GET: todo_pro
        loginDAO log = new loginDAO();
        usuarioDAO usuario_dao = new usuarioDAO();
        BackEndDAO Obj_back = new BackEndDAO();

        public ActionResult IndexFinal()
        {
            return View( );
        }

        public ActionResult IndexPro()
        {
            return View();
        }



        public ActionResult vacio()
        {
            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }



        
        public ActionResult guardar(usuarioBO usua)
        {
            
           
            
                usuario_dao.guardar(usua);
                return Redirect("~/todo_pro/IndexFinal");
            

            
           
        }






        public ActionResult cerrar()
        {
            Session.Remove("usuario");
            Session.Abandon();
            return Redirect("~/todo_pro/IndexFinal");
        }
        public ActionResult registro()
        {

            if (Session["usuario"] != null)
            {
                ViewBag.usuario = (usuarioBO)Session["usuario"];
                return View();
            }
            return View();
        }
      
        public ActionResult login(usuarioBO usuario)
        {
            if (log.verificar(usuario))
            {
                var i = log.buscarelid(usuario);

                Response.Write("<script>alert('usuario correcto')</script>");
                usuarioBO usu = log.obtener(usuario.nombre, usuario.contraseña);
                Session["usuario"] = usu;
                
                if (i == 1)
                {


                    return Redirect("~/usuariofron/miscontactos");

                }
                else if (i == 2)
                {
                    return Redirect("~/VBackend/inicio");
                }
                            

            }
           
        return Redirect("~/todo_pro/indexPro");
            

            
      
        }
    }
}