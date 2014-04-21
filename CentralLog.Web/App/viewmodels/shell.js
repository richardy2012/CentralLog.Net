define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function () {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: 'Main', moduleId: 'viewmodels/main', nav: true },
                { route: 'groups/edit', title: 'Edit Groups', moduleId: 'viewmodels/groups/edit', nav: true }
                //{ route: 'flickr', moduleId: 'viewmodels/flickr', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});