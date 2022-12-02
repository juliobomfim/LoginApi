import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit{
  loginForm!: FormGroup;
  authFailed: boolean = false;
  signedIn: boolean = false;

  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.authService.isSignedIn().subscribe(
      isSignedIn => {
        this.signedIn = isSignedIn;
      }
    );
  }

  ngOnInit(): void {
    this.authFailed = false;
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  public signIn(event: any){
    if (!this.loginForm.valid){
      return;
    }

    const userName = this.loginForm.get('username')?.value;
    const password = this.loginForm.get('password')?.value;

    this.authService.signIn(userName, password).subscribe(
      {
        next: (response) => {
          if (response.ok){
            this.router.navigateByUrl('user')
          }
        },
        error: (error) => {
          if (!error?.error?.IsSuccess){
            this.authFailed = true;
          }
        }
      }
    )
  }

}
