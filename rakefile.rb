require 'rake/clean'

@build_dir = 'build'

CLEAN.include(@build_dir)
task :default => [:hello, :clean, :build]

task :hello do
	puts 'hello world'
end

task :clean do
	CLEAN.include (FileList["./src/**/bin/"])
	CLEAN.include (FileList["./src/**/obj/"])
end

task :build do

end