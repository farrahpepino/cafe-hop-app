import { Routes } from '@angular/router';
import { Auth } from './components/auth/auth';
import { Home } from './components/home/home';
import { authGuard } from './Guards/auth-guard';

export const routes: Routes = [
    {
        path: '',
        component: Auth
    },
    {
        path: 'home',
        component: Home,
        canActivate: [authGuard]
    }
];
