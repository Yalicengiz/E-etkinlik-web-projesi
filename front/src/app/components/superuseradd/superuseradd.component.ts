import { LocalStorageService } from './../../services/localStorageService/local-storage.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../../services/loginService/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-superuseradd',
  templateUrl: './superuseradd.component.html',
  styleUrls: ['./superuseradd.component.css']
})
export class SuperuseraddComponent implements OnInit {
  superUserAddForm: FormGroup;
  apiUrl = 'https://localhost:5001/api/auth/superuser';
  constructor(
    private authService: AuthService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private router: Router,
    private httpClient: HttpClient,
    private _localStorage: LocalStorageService
  ) { }

  ngOnInit(): void {
    this.createSuperUserAddAddForm();
  }
  createSuperUserAddAddForm() {
    this.superUserAddForm = this.formBuilder.group({
      url: ['', Validators.required],
      tckn:  ['', Validators.required]
    });
  }

  add() {
    if (this.superUserAddForm.valid) {
      this.authService.superUser().subscribe((data) => {
        this._localStorage.set("opId","3");
        this.toastrService.success('Süper kullanıcı oldunuz');
        this.router.navigateByUrl("")
      });
    } else {
      this.toastrService.error('Eksik bilgiler');
    }
  }

}
