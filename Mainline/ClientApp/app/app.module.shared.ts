import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { TrainListComponent } from './components/control/trainList.component';
import { ThrottleComponent } from './components/control/throttle.component';
import { TrainControlComponent } from './components/control/trainControl.component';
import { LayoutComponent } from './components/control/layout.component';

import { TrackPieceComponent } from './components/track/trackPiece.component';
import { StraightTrackComponent } from './components/track/straightTrack.component';

import { TrainService } from './components/services/train.service';
import { ThrottleService } from './components/services/throttle.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        TrainListComponent,
        ThrottleComponent,
        TrainControlComponent,
        LayoutComponent,

        TrackPieceComponent,
        StraightTrackComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'train-list', component: TrainListComponent },
            { path: 'layout', component: LayoutComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        TrainService,
        ThrottleService
    ]
})
export class AppModuleShared {
}
