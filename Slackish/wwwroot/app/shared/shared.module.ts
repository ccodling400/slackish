import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import {AuthGuardService} from "./auth-guard.service"
import {AuthenticationService} from "./authentication.service";
import {HttpService} from "./http.service";
import {LoginRedirectService} from "./login-redirect.service";
import { SignalR } from "./signalr";
import {Storage} from "./storage.service";

const providers = [HttpService, SignalR, AuthGuardService, LoginRedirectService, Storage];

@NgModule({
    imports: [CommonModule],
    providers: providers
})
export class SharedModule { }