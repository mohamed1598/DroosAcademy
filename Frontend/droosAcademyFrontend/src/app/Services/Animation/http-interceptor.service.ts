import { Observable } from 'rxjs';
import { Injectable, NgZone } from '@angular/core';
import { HttpInterceptor, HttpResponse } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { HttpHandler } from '@angular/common/http';
import { HttpEvent } from '@angular/common/http';
import { delay, tap } from 'rxjs/operators';
import { SpinnerService } from './spinner-service.service';
import { LoginService } from '../login.service';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {

     constructor(private spinnerService: SpinnerService,private ngZone:NgZone,private loginService:LoginService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      // console.log(this.loginService.getToken());
      
      req = req.clone({
        setHeaders: {
          'Content-Type' : 'application/json; charset=utf-8',
          'Accept'       : 'application/json',
          'Authorization': `Bearer ${this.loginService.getToken()}`,
        },
      });
      setTimeout(() => {
        this.spinnerService.show();
        // console.log("show");
      }, 10);
        
        return next
            .handle(req)
            .pipe(
                tap((event: HttpEvent<any>) => {
                    if (event instanceof HttpResponse) {
                      setTimeout(() => {
                        this.spinnerService.hide();
                        // console.log("hide");
                      }, 10);
                        
                        
                    }
                }, (error) => {
                  setTimeout(() => {
                    this.spinnerService.hide();
                    // console.log("hide");
                  }, 10);
                    
                })
            );
    }
}