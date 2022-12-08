import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth/auth.component';
import { UserComponent } from './auth/user/user.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [{
  path: 'auth',
  component: AuthComponent,
  pathMatch: 'full',
  canActivate: [AuthGuard]
},
{
  path: 'user',
  component: UserComponent,
  pathMatch: 'full',
  canActivate: [AuthGuard]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],

})
export class AppRoutingModule { }
