import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./pages/home/home').then((m) => m.Home),

    },
    {
        path: 'comments',
        loadComponent: () => import('./pages/comments/comments').then((m) => m.Comments),
    },
    {
        path: 'login',
        loadComponent: () => import('./pages/login/login').then((m) => m.Login),
    },
    {
        path: 'register',
        loadComponent: () => import('./pages/register/register').then((m) => m.Register),
    }
];
