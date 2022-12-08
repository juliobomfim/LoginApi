import { Component } from '@angular/core';
import { UserClaim } from 'src/app/model/auth';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  userClaims: UserClaim[] = [];
  constructor(private authService: AuthService){
    this.getUser();
  }

  private getUser(){
    this.authService.getUser().subscribe(result => {
      this.userClaims = result;
    });
  }
}
