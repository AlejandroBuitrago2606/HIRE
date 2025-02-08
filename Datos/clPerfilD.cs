using HIRE.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIRE.Datos
{
    public class clPerfilD
    {

        ClConexion objConexion = new ClConexion();

        public clTraerPerfilCV mtdListarPerfil(int idUsuario)
        {
            clTraerPerfilCV objPerfilDatos = new clTraerPerfilCV();

            try
            {
                SqlCommand cmd = new SqlCommand("spTraerPerfilCV", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    clPerfilE objPerfilCV = new clPerfilE();
                    List<clCompetenciaE> objCompetenciaCV = new List<clCompetenciaE>();
                    List<clExperienciaE> objExperienciaCV = new List<clExperienciaE>();
                    List<clReferenciaE> objReferenciaCV = new List<clReferenciaE>();
                    List<clCertificacionE> objCertificacionCV = new List<clCertificacionE>();
                    List<clProyectoDesarrolloE> objProyectoDesarrolloCV = new List<clProyectoDesarrolloE>();
                    List<clIdiomaE> objIdiomaCV = new List<clIdiomaE>();
                    List<clLogroAcademicoE> objLogroAcademicoCV = new List<clLogroAcademicoE>();




                    if (fila.HasRows)
                    {
                        while (fila.Read())
                        {

                            objPerfilCV.idCurriculumVitae = int.Parse(fila["idCurriculumVitae"].ToString());
                            objPerfilCV.perfilProfesional = fila["perfilProfesional"].ToString();
                            objPerfilCV.hojaVida = fila["hojaVida"].ToString();

                        }
                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {

                                objCompetenciaCV.Add(new clCompetenciaE
                                {

                                    idCurriculumVitaeCompetencia = int.Parse(fila["idCurriculumVitaeCompetencia"].ToString()),
                                    idCompetencia = int.Parse(fila["idCompetencia"].ToString()),
                                    nombre = fila["nombre"].ToString(),
                                    descripcion = fila["descripcion"].ToString(),
                                    idCategoria = int.Parse(fila["idCategoria"].ToString()),
                                    nombreCategoria = fila["nombreCategoria"].ToString()

                                });



                            }


                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {

                                objExperienciaCV.Add(new clExperienciaE
                                {
                                    idExperiencia = int.Parse(fila["idExperiencia"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    descripcion = fila["descripcion"].ToString(),
                                    soporte = fila["soporte"].ToString()

                                });
                            }

                        }

                        if (fila.NextResult())
                        {
                            while (fila.Read())
                            {

                                objReferenciaCV.Add(new clReferenciaE
                                {
                                    idReferencia = int.Parse(fila["idReferencia"].ToString()),
                                    nombreReferencia = fila["nombreReferencia"].ToString(),
                                    cargo = fila["cargo"].ToString(),
                                    nombreEmpresa = fila["nombreEmpresa"].ToString(),
                                    telefono = fila["telefono"].ToString(),
                                    correo = fila["correo"].ToString(),
                                    tipoReferencia = fila["tipoReferencia"].ToString(),
                                    relacionProfesional = fila["relacionProfesional"].ToString(),

                                });

                            }

                        }

                        if (fila.NextResult())
                        {


                            while (fila.Read())
                            {
                                objCertificacionCV.Add(new clCertificacionE
                                {

                                    idCertificacion = int.Parse(fila["idCertificacion"].ToString()),
                                    descripcionCertificacion = fila["descripcionCertificacion"].ToString(),
                                    nombreInstitucion = fila["nombreInstitucion"].ToString(),
                                    fechaObtencion = fila["fechaObtencion"].ToString(),

                                });
                            }



                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {
                                objProyectoDesarrolloCV.Add(new clProyectoDesarrolloE
                                {
                                    idProyectoDesarrollo = int.Parse(fila["idProyectoDesarrollo"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    descripcion = fila["descripcion"].ToString(),

                                });



                            }


                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {
                                objIdiomaCV.Add(new clIdiomaE
                                {
                                    idIdioma = int.Parse(fila["idIdioma"].ToString()),
                                    nombre = fila["nombre"].ToString(),
                                    nivel = fila["nivel"].ToString(),

                                });

                            }



                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {
                                objLogroAcademicoCV.Add(new clLogroAcademicoE
                                {
                                    idLogroAcademico = int.Parse(fila["idLogroAcademico"].ToString()),
                                    tituloLogroAcademico = fila["tituloLogroAcademico"].ToString(),
                                    nombreInstitucion = fila["nombreInstitucion"].ToString(),
                                    periodoTiempo = fila["periodoTiempo"].ToString(),
                                    ubicacion = fila["ubicacion"].ToString(),
                                    fechaEntrega = fila["fechaEntrega"].ToString(),
                                    nivel = fila["nivel"].ToString(),

                                });

                            }




                        }
                    }
                    else
                    {
                        objPerfilCV.perfilProfesional = "Agrega información a tu perfil profesional";
                    }


                    fila.Close();
                    objConexion.MtdCerrarConexion();

                    objPerfilDatos.objDatosCV = objPerfilCV;
                    objPerfilDatos.objCompetenciaCV = objCompetenciaCV;
                    objPerfilDatos.objExperienciaCV = objExperienciaCV;
                    objPerfilDatos.objReferenciaCV = objReferenciaCV;
                    objPerfilDatos.objCertificacionCV = objCertificacionCV;
                    objPerfilDatos.objProyectoDesarrolloCV = objProyectoDesarrolloCV;
                    objPerfilDatos.objIdiomaCV = objIdiomaCV;
                    objPerfilDatos.objLogroAcademicoCV = objLogroAcademicoCV;

                }
            }
            catch (Exception e)
            {

                objPerfilDatos = null;

                Console.WriteLine(e.Message);

            }

            return objPerfilDatos;
        }

        public bool mtdRegistrarCvD(int opcion, clDetallesPerfilCV objDatosCV, int idCV = 0)
        {

            bool validar = false;

            try
            {
                SqlCommand cmd = new SqlCommand("spRegistrarDetallesCV", objConexion.MtdAbrirConexion());

                switch (opcion)
                {


                    case 1:

                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.DatosCV.perfilProfesional);
                        cmd.Parameters.AddWithValue("@urlArchivo", objDatosCV.DatosCV.hojaVida);
                        cmd.Parameters.AddWithValue("@idUsuario", objDatosCV.DatosCV.idUsuario);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;

                    case 2:


                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@idCompetencia", int.Parse(objDatosCV.CompetenciaCV.idCompetencia.ToString()));
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 3:

                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.certificacionCV.descripcionCertificacion);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.certificacionCV.nombreInstitucion);
                        cmd.Parameters.AddWithValue("@fecha", objDatosCV.certificacionCV.fechaObtencion);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 4:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.proyectoDesarrolloCV.titulo);
                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.proyectoDesarrolloCV.descripcion);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 5:

                        cmd.Parameters.AddWithValue("@nombre", objDatosCV.referenciaCV.nombreReferencia);
                        cmd.Parameters.AddWithValue("@cargo", objDatosCV.referenciaCV.cargo);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.referenciaCV.nombreEmpresa);
                        cmd.Parameters.AddWithValue("@telefono", objDatosCV.referenciaCV.telefono);
                        cmd.Parameters.AddWithValue("@correo", objDatosCV.referenciaCV.correo);
                        cmd.Parameters.AddWithValue("@tipoReferencia", objDatosCV.referenciaCV.tipoReferencia);
                        cmd.Parameters.AddWithValue("@relacionProfesional", objDatosCV.referenciaCV.relacionProfesional);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 6:

                        cmd.Parameters.AddWithValue("@nombre", objDatosCV.idiomaCV.nombre);
                        cmd.Parameters.AddWithValue("@nivel", objDatosCV.idiomaCV.nivel);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 7:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.ExperienciaCV.titulo);
                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.ExperienciaCV.descripcion);
                        cmd.Parameters.AddWithValue("@urlArchivo", objDatosCV.ExperienciaCV.soporte);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 8:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.logroAcademicoCV.tituloLogroAcademico);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.logroAcademicoCV.nombreInstitucion);
                        cmd.Parameters.AddWithValue("@periodo", objDatosCV.logroAcademicoCV.periodoTiempo);
                        cmd.Parameters.AddWithValue("@ubicacion", objDatosCV.logroAcademicoCV.ubicacion);
                        cmd.Parameters.AddWithValue("@fecha", objDatosCV.logroAcademicoCV.fechaEntrega);
                        cmd.Parameters.AddWithValue("@idNivelAcademico", objDatosCV.logroAcademicoCV.idNivelAcademico);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;


                }

                objConexion.MtdCerrarConexion();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            return validar;
        }

        public (List<clCompetenciaE>, List<clNivelAcademicoE>) mtdListarFiltros()
        {
            List<clNivelAcademicoE> objNivelAcademico = new List<clNivelAcademicoE>();
            List<clCompetenciaE> objCompetencia = new List<clCompetenciaE>();
            //List<List<clCompetenciaE>> objFiltros = new List<List<clCompetenciaE>>();
            try
            {

                SqlCommand cmd = new SqlCommand("spListarFiltros", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@filtros2", 2);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader resultado = cmd.ExecuteReader())
                {


                    if (resultado.HasRows)
                    {

                        while (resultado.Read())
                        {

                            objNivelAcademico.Add(new clNivelAcademicoE
                            {

                                idVacanteNivelAcademico = int.Parse(resultado["idNivelAcademico"].ToString()),
                                nivelAcademico = resultado["nivel"].ToString()


                            });



                        }


                    }
                    if (resultado.NextResult() && resultado.HasRows)
                    {
                        while (resultado.Read())
                        {
                            objCompetencia.Add(new clCompetenciaE
                            {

                                idCompetencia = int.Parse(resultado["idCompetencia"].ToString()),
                                nombre = resultado["nombre"].ToString(),
                                descripcion = resultado["descripcion"].ToString()

                            });

                        }

                    }
                    else
                    {
                        objNivelAcademico = null;
                        objCompetencia = null;
                    }
                    resultado.Close();


                }
                objConexion.MtdCerrarConexion();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return (objCompetencia, objNivelAcademico);

        }

        public bool mtdActualizarCV(int opcion, clDetallesPerfilCV objDatosCV, int idCV = 0)
        {


            bool validar = false;

            try
            {
                SqlCommand cmd = new SqlCommand("spActualizarCV", objConexion.MtdAbrirConexion());

                switch (opcion)
                {


                    case 11:

                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.DatosCV.perfilProfesional);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 12:

                        cmd.Parameters.AddWithValue("@urlArchivo", objDatosCV.DatosCV.hojaVida);
                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 2:


                        cmd.Parameters.AddWithValue("@idCV", idCV);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.CompetenciaCV.idCurriculumVitaeCompetencia);
                        cmd.Parameters.AddWithValue("@idCompetencia", objDatosCV.CompetenciaCV.idCompetencia);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 3:

                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.certificacionCV.descripcionCertificacion);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.certificacionCV.nombreInstitucion);
                        cmd.Parameters.AddWithValue("@fecha", objDatosCV.certificacionCV.fechaObtencion);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.certificacionCV.idCertificacion);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 4:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.proyectoDesarrolloCV.titulo);
                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.proyectoDesarrolloCV.descripcion);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.proyectoDesarrolloCV.idProyectoDesarrollo);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 5:

                        cmd.Parameters.AddWithValue("@nombre", objDatosCV.referenciaCV.nombreReferencia);
                        cmd.Parameters.AddWithValue("@cargo", objDatosCV.referenciaCV.cargo);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.referenciaCV.nombreEmpresa);
                        cmd.Parameters.AddWithValue("@telefono", objDatosCV.referenciaCV.telefono);
                        cmd.Parameters.AddWithValue("@correo", objDatosCV.referenciaCV.correo);
                        cmd.Parameters.AddWithValue("@tipoReferencia", objDatosCV.referenciaCV.tipoReferencia);
                        cmd.Parameters.AddWithValue("@relacionProfesional", objDatosCV.referenciaCV.relacionProfesional);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.referenciaCV.idReferencia);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 6:

                        cmd.Parameters.AddWithValue("@nombre", objDatosCV.idiomaCV.nombre);
                        cmd.Parameters.AddWithValue("@nivel", objDatosCV.idiomaCV.nivel);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.idiomaCV.idIdioma);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 7:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.ExperienciaCV.titulo);
                        cmd.Parameters.AddWithValue("@descripcion", objDatosCV.ExperienciaCV.descripcion);
                        cmd.Parameters.AddWithValue("@urlArchivo", objDatosCV.ExperienciaCV.soporte);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.ExperienciaCV.idExperiencia);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;
                    case 8:

                        cmd.Parameters.AddWithValue("@titulo", objDatosCV.logroAcademicoCV.tituloLogroAcademico);
                        cmd.Parameters.AddWithValue("@nombreEntidad", objDatosCV.logroAcademicoCV.nombreInstitucion);
                        cmd.Parameters.AddWithValue("@periodo", objDatosCV.logroAcademicoCV.periodoTiempo);
                        cmd.Parameters.AddWithValue("@ubicacion", objDatosCV.logroAcademicoCV.ubicacion);
                        cmd.Parameters.AddWithValue("@fecha", objDatosCV.logroAcademicoCV.fechaEntrega);
                        cmd.Parameters.AddWithValue("@idNivelAcademico", objDatosCV.logroAcademicoCV.idNivelAcademico);
                        cmd.Parameters.AddWithValue("@idDetalle", objDatosCV.logroAcademicoCV.idLogroAcademico);
                        cmd.Parameters.AddWithValue("@opcion", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        validar = true;

                        break;




                }



                objConexion.MtdCerrarConexion();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            return validar;

        }

        public clDetallesPerfilCV mtdTraerDetalle(int opcion, int idDetalle2)
        {

            clDetallesPerfilCV objDetallePerfil = new clDetallesPerfilCV();
            try
            {

                SqlCommand cmd = new SqlCommand("spActualizarCV", objConexion.MtdAbrirConexion());
                switch (opcion)
                {

                    case 1:


                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clPerfilE objDetallesCV = new clPerfilE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {
                                    objDetallesCV.perfilProfesional = fila["perfilProfesional"].ToString();
                                }
                                objDetallePerfil.DatosCV = objDetallesCV;
                            }
                            fila.Close();
                        }
                        break;
                    case 2:


                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clCompetenciaE objCompt = new clCompetenciaE();
                            if (fila.HasRows)
                            {

                                while (fila.Read())
                                {

                                    objCompt.idCurriculumVitaeCompetencia = int.Parse(fila["idCVCompetencia"].ToString());
                                    objCompt.idCompetencia = int.Parse(fila["idCompetencia"].ToString());

                                }
                                objDetallePerfil.CompetenciaCV = objCompt;
                            }
                            fila.Close();
                        }

                        break;
                    case 3:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {

                            clCertificacionE objCertf = new clCertificacionE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {
                                    objCertf.idCertificacion = int.Parse(fila["idCertificacion"].ToString());
                                    objCertf.descripcionCertificacion = fila["descripcion"].ToString();
                                    objCertf.nombreInstitucion = fila["nombreInstitucion"].ToString();
                                    objCertf.fechaObtencion = fila["fechaObtencion"].ToString();

                                }
                                objDetallePerfil.certificacionCV = objCertf;
                            }
                            fila.Close();
                        }
                        break;
                    case 4:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {

                            clProyectoDesarrolloE objProD = new clProyectoDesarrolloE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {
                                    objProD.idProyectoDesarrollo = int.Parse(fila["idProyectoDesarrollo"].ToString());
                                    objProD.titulo = fila["titulo"].ToString();
                                    objProD.descripcion = fila["descripcion"].ToString();

                                }
                                objDetallePerfil.proyectoDesarrolloCV = objProD;
                            }
                            fila.Close();
                        }

                        break;
                    case 5:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clReferenciaE objRef = new clReferenciaE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {

                                    objRef.idReferencia = int.Parse(fila["idReferencia"].ToString());
                                    objRef.nombreReferencia = fila["nombre"].ToString();
                                    objRef.cargo = fila["cargo"].ToString();
                                    objRef.nombreEmpresa = fila["nombreEmpresa"].ToString();
                                    objRef.telefono = fila["telefono"].ToString();
                                    objRef.correo = fila["correo"].ToString();
                                    objRef.tipoReferencia = fila["tipoReferencia"].ToString();
                                    objRef.relacionProfesional = fila["relacionProfesional"].ToString();
                                }
                                objDetallePerfil.referenciaCV = objRef;
                            }
                            fila.Close();
                        }


                        break;
                    case 6:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clIdiomaE objIdioma = new clIdiomaE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {

                                    objIdioma.idIdioma = int.Parse(fila["idIdioma"].ToString());
                                    objIdioma.nombre = fila["nombre"].ToString();
                                    objIdioma.nivel = fila["nivel"].ToString();

                                }
                                objDetallePerfil.idiomaCV = objIdioma;
                            }
                            fila.Close();
                        }

                        break;
                    case 7:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clExperienciaE objExp = new clExperienciaE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {
                                    objExp.idExperiencia = int.Parse(fila["idExperiencia"].ToString());
                                    objExp.titulo = fila["titulo"].ToString();
                                    objExp.descripcion = fila["descripcion"].ToString();
                                    objExp.soporte = fila["soporte"].ToString();
                                }
                                objDetallePerfil.ExperienciaCV = objExp;
                            }
                            fila.Close();
                        }

                        break;
                    case 8:

                        cmd.Parameters.AddWithValue("@listarDetalles", 1);
                        cmd.Parameters.AddWithValue("@idDetalle2", idDetalle2);
                        cmd.Parameters.AddWithValue("@opcion2", opcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            clLogroAcademicoE objLogroA = new clLogroAcademicoE();
                            if (fila.HasRows)
                            {
                                while (fila.Read())
                                {
                                    objLogroA.idLogroAcademico = int.Parse(fila["idLogroAcademico"].ToString());
                                    objLogroA.tituloLogroAcademico = fila["titulo"].ToString();
                                    objLogroA.nombreInstitucion = fila["nombreInstitucion"].ToString();
                                    objLogroA.periodoTiempo = fila["periodoTiempo"].ToString();
                                    objLogroA.ubicacion = fila["ubicacion"].ToString();
                                    objLogroA.fechaEntrega = fila["fechaEntrega"].ToString();
                                    objLogroA.idNivelAcademico = int.Parse(fila["idNivelAcademico"].ToString());

                                }
                                objDetallePerfil.logroAcademicoCV = objLogroA;
                            }
                            fila.Close();
                        }

                        break;

                }
                objConexion.MtdCerrarConexion();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return objDetallePerfil;
        }


    }

}