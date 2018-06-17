import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Credentials} from '../../models/credentials';
import {Title} from '@angular/platform-browser';
import {Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  userData: Credentials;
  invalidCredentials: boolean;

  constructor(private fb: FormBuilder,
              private authService: AuthService,
              private title: Title,
              private router: Router) { }

  ngOnInit() {
    this.title.setTitle('Login');
    this.form = this.fb.group({
      username: [''],
      password: ['']
    });
  }

  submit() {
    this.userData = this.form.value as Credentials;
    console.log(this.userData);

    this.authService.authorize(this.userData).subscribe(
      res => {
        console.log(res);

        if (res) {
          this.authService.storeToken(res);
          this.router.navigate(['/home']);
        }
      },
      err => {
        console.log(err.status);
        if(err.status === 401) {
          this.invalidCredentials = true;
        }
      });
  }

  inputChange() {
    this.invalidCredentials = false;
  }

}
