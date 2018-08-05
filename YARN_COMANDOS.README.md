### INSTALL YARN
```
npm install -g yarn
```

### INIT YARN
```
yarn init
```

### INSTALL JS PACKAGE
```
yarn add "jquery"
```

### UPGRADE JS PACKAGE
```
yarn upgrade "jquery"
```

### REMOVE JS PACKAGE
```
yarn remove "jquery"
```

### INSTALL ALL JS PACKAGES
```
yarn install
```

### INSTALL GULP
```
yarn install gulp
```

### INSTALL GULP-CONCAT
```
yarn install gulp-concat
```

### INSTALL GULP-CONCAT
```
yarn install gulp-cssmin
```

### INSTALL GULP-UNCSS
```
yarn install gulp-uncss
```

## CREATE GULP PROCESS
### BROWSER-SYNC IT UPDATES YOUR WEBPAGE EVERYTIME YOU UPDATE YOUR JS/CSS FILE
```
var gulp = require('gulp');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function(){
    browserSync.init({
        proxy: 'https://localhost:5001'
    });
    gulp.watch('./styles/**/*.css', ['css']);
    gulp.watch('./js/**/*.js', ['js']);
});

gulp.task('js', function(){
    return gulp.src([
        './node_modules/vue/dist/vue.min.js',
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'));
});
```

### MIGRACAO DOS ARQUIVOS CSS
```
var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');

gulp.task('js', function(){
    return gulp.src([
        './node_modules/vue/dist/vue.min.js',
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'));
});
```

### MIGRACAO DOS ARQUIVOS CSS
```
gulp.task('css', function(){
    return gulp.src([
        './styles/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css'
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css/'));
});
```

### ELE CRIA UM PROCESSO PARA FICAR VERIFICANDO E ATUALIZA SEU STYLE FINAL
```
gulp.task('watch-css', function(){
    gulp.watch('./styles/**/*.css', ['css'])
});
```

### RUN GULP PROCESS
```
yarn gulp "js"

yarn gulp "css"

yarn gulp "watch-css"

yarn gulp "browser-sync"
```