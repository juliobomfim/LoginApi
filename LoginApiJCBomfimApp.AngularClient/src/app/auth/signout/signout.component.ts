import { Component } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-signout',
  templateUrl: './signout.component.html',
  styleUrls: ['./signout.component.scss']
})
export class SignoutComponent {
    constructor(private authService: AuthService){
        this.signOut();
    }

    public signOut(){
      this.authService.signOut().subscribe();
    }
}
