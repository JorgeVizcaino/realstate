import { Injectable, ErrorHandler, Injector } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class GlobalErrorHandlerService implements ErrorHandler {
  constructor(private injector: Injector
    , private toastr: ToastrService) { }

  handleError(error: any) {
    const router = this.injector.get(Router);
    console.error("URL: " + router.url);

    if (error.error) {
      if (error.error.error) {
        console.error("Response detalle:", error.error.error.join(", "));
      }
    }
    if (error instanceof HttpErrorResponse) {
      // Backend returns unsuccessful response codes such as 404, 500 etc.
      console.error("Backend returned status code: ", error.status);
      console.error("Response body:", error.message);
      this.toastr.error("Ha ocurrido un error inesperado", "Error", { onActivateTick: true });

    } else {
      // A client-side or network error occurred.
      console.error("An error occurred:", error.message);
      this.toastr.error("Ha ocurrido un error inesperado", "Error", { onActivateTick: true });
    }
  }
}
