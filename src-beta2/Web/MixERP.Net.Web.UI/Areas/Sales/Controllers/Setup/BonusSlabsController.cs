﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System.Web.Mvc;
using MixERP.Net.UI.ScrudFactory;
using MixERP.Net.Web.UI.Sales.Resources;
using MixERP.Net.Web.UI.Providers;
using System.Collections.Generic;
using MixERP.Net.Common.Helpers;

namespace MixERP.Net.Web.UI.Sales.Controllers.Setup
{
    [RouteArea("Sales")]
    [RoutePrefix("setup/bonus-slabs")]
    [Route("{action=index}")]
    public class BonusSlabsController : ScrudController
    {
        public ActionResult Index()
        {
            const string view = "~/Areas/Sales/Views/Setup/BonusSlabs.cshtml";
            return View(view, this.GetConfig());
        }

        public override Config GetConfig()
        {
            Config config = ScrudProvider.GetScrudConfig();

            config.KeyColumn = "bonus_slab_id";

            config.TableSchema = "core";
            config.Table = "bonus_slabs";

            config.ViewSchema = "core";
            config.View = "bonus_slab_scrud_view";
            config.DisplayFields = GetDisplayFields();
            config.DisplayViews = GetDisplayViews();

            config.Text = Titles.AgentBonusSlabs;

            config.ResourceAssembly = typeof(BonusSlabsController).Assembly;
            this.AddScrudCustomValidatorErrorMessages();

            return config;
        }

        private void AddScrudCustomValidatorErrorMessages()
        {
            ViewData["DateErrorMessage"] = Warnings.DateErrorMessage;
        }


        private static string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "core.frequencies.frequency_id", ConfigurationHelper.GetDbParameter("FrequencyDisplayField"));
            return string.Join(",", displayFields);
        }

        private static string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "core.frequencies.frequency_id", "core.frequency_selector_view");
            return string.Join(",", displayViews);
        }
    }
}
