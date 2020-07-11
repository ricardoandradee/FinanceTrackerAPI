// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api/',
  firebase: {
    apiKey: "AIzaSyCmIHokdF2w0h5_3vHllcrqAoUWOWDBU0E",
    authDomain: "ng-finance-tracker.firebaseapp.com",
    databaseURL: "https://ng-finance-tracker.firebaseio.com",
    projectId: "ng-finance-tracker",
    storageBucket: "ng-finance-tracker.appspot.com",
    messagingSenderId: "842406636729",
    appId: "1:842406636729:web:5955908578dd2019b3bf68",
    measurementId: "G-85TVB5F2BF"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
