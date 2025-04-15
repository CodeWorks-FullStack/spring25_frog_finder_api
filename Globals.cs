// NOTE all of these global statements make it so we don't have to add the 'using' statement for theses namespaces in any of our files in this application

global using System;
global using System.Data;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using System.Threading.Tasks;
global using Dapper;
global using CodeWorks.Utils;

// APPLICATION SPECIFIC
global using frog_finder_api.Repositories;
global using frog_finder_api.Services;
global using frog_finder_api.Models;