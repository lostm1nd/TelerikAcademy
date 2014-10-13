/* global module, require */
'use strict';

module.exports = function (grunt) {
  require('load-grunt-tasks')(grunt);

  grunt.initConfig({
    coffee: {
      compile: {
        files: {
          '../app/js/app.js': 'js/app.coffee'
        }
      }
    },
    jshint: {
      app: ['../app/js/**/*.js']
    },
    jade: {
      compile: {
        options: {
          pretty: true
        },
        files: {
          '../app/index.html': 'index.jade'
        }
      }
    },
    stylus: {
      compile: {
        options: {
          compress: false
        },
        files: {
          '../app/css/styles.css': 'css/styles.styl'
        }
      }
    },
    copy: {
      app: {
        src: 'images/*',
        dest: '../app/'
      }
    },
    connect: {
      options: {
        port: 9999,
        livereload: 35729,
        hostname: 'localhost'
      },
      livereload: {
        options: {
          open: true,
          base: [
            '../app/'
          ]
        }
      }
    },
    watch: {
      jade: {
        files: ['./*.jade'],
        tasks: ['jade'],
        options: {
          livereload: true
        }
      },
      coffee: {
        files: ['js/**/*.coffee'],
        tasks: ['coffee'],
        options: {
          livereload: true
        }
      },
      stylus: {
        files: ['css/**/*.styl'],
        tasks: ['stylus'],
        options: {
          livereload: true
        }
      },
      livereload: {
        options: {
          livereload: '35729'
        },
        files: [
          '../app/*.html',
          '../app/css/*.css',
          '../app/js/*.js'
        ]
      }
    },
  });

  grunt.registerTask('serve', ['jade', 'coffee', 'stylus', 'copy', 'connect', 'watch']);
  // grunt.registerTask('build', []);
};
