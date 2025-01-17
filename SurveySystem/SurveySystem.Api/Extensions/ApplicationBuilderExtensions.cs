<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using SurveySystem.Api.Middleware;
using SurveySystem.Infrastructure;
=======
﻿using SurveySystem.Api.Middleware;
using SurveySystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
>>>>>>> b14d977 (Update db connection string)
=======
﻿using Microsoft.EntityFrameworkCore;
using SurveySystem.Api.Middleware;
using SurveySystem.Infrastructure;
>>>>>>> 906bf84 (fixed)
=======
﻿using SurveySystem.Api.Middleware;
using SurveySystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
>>>>>>> b75042a (Rebase)

namespace SurveySystem.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
=======
=======
>>>>>>> b75042a (Rebase)
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

<<<<<<< HEAD
>>>>>>> b14d977 (Update db connection string)
=======
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
>>>>>>> 906bf84 (fixed)
=======
>>>>>>> b75042a (Rebase)
        dbContext.Database.Migrate();
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> b14d977 (Update db connection string)
=======
}
>>>>>>> 906bf84 (fixed)
=======
}
>>>>>>> b75042a (Rebase)
