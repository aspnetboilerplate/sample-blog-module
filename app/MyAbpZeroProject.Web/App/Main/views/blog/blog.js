(function () {

    angular.module('app').config([
        '$stateProvider',
        function ($stateProvider) {
            $stateProvider
                .state('blog', {
                    url: '/blog',
                    templateUrl: '/App/Main/views/blog/blog.cshtml',
                    menu: 'SampleBlog.AdminPage'
                });
        }
    ]);

    angular.module('app').controller('app.views.blog', [
        '$scope', 'abp.services.blog.post',
        function ($scope, postService) {
            var vm = this;

            vm.posts = [];

            postService.getPosts({
                maxResultCount: 1000
            }).then(function (result) {
                vm.posts = result.data.items;
            });
        }
    ]);
})();