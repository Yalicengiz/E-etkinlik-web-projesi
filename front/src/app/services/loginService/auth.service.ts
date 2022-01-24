import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from 'src/app/models/loginModel';
import { TokenModel } from 'src/app/models/tokenModel';
import { SingleResponseModel } from 'src/app/models/singleResponseModel';
import { LocalStorageService} from 'src/app/services/localStorageService/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = 'https://localhost:5001/api/auth/login';
  private helper: JwtHelperService = new JwtHelperService();
  constructor(private httpClient: HttpClient,private localStorageService:LocalStorageService, private storage:LocalStorageService) {}

  login(loginModel: LoginModel): Observable<TokenModel> {
    return this.httpClient.post<TokenModel>(
      this.apiUrl,
      loginModel
    );
  }

  isAuthenticated() {
    if (localStorage.getItem('token')) {
      return true;
    } else {
      return false;
    }
  }

  superUser(){
    return  this.httpClient.get(
      "https://localhost:5001/api/auth/superuser?id="+
      parseInt(this.localStorageService.get("id"))
    );
  }


  logOut(){
    this.localStorageService.clear()
  }

  getCurrentFullName(): string {
    let token: string = localStorage.getItem('token');
    if (token) {
      let decoded = this.helper.decodeToken(token);
      let userName = Object.keys(decoded).filter((x) => x.endsWith('/name'))[0];
      return decoded[userName];
    }
    return null;
  }

}
