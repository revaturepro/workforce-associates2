﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Associates2.Domain;
using Workforce.Logic.Associates2.Domain.DomainModels;

namespace Workforce.Logic.Associates2.Rest.Controllers
{
  public class AssociateController : ApiController
   {
      private readonly LogicHelper logic = new LogicHelper();
      private static readonly log4net.ILog logger = LogHelper.GetLogger();
      /// <summary>
      /// This 'Get' method will get every Associate that exists in the database
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllAssociates());
          logger.Info("Get all associates successful");
          return response;
        }

        catch(Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// This is the base 'Get' method for Associate that returns results based on active status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAssociatesByStatus(status));
          logger.Info("Find associate by status successful");
          return response;
        }

        catch(Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);          
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]AssociateDto associate)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewAssociate(associate));
          logger.Info("Add New Associate Successful");
          return response;
        }
        
        catch(Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]AssociateDto associate)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateAssociate(associate));
          logger.Info("Delete Associate Successful");
          return response;
        }
        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]AssociateDto associate)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateAssociate(associate));
          logger.Info("Update Associate Successful");
          return response;
        }
        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
         
      }
   }
}