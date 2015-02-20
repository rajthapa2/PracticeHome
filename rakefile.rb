require 'rake/clean'
require 'albacore'

@build_dir = 'build'

CLEAN.include(@build_dir)
task :default => [:hello, :clean, :restore, :build]

task :hello do
	puts 'hello world'
end

task :clean do
	CLEAN.include (FileList["./src/**/bin/"])
	CLEAN.include (FileList["./src/**/obj/"])
end


nugets_restore :restore do |p|
	p.out = 'src/packages'
	p.exe = 'tools/Nuget.exe'
end

desc 'Perform full build'
build :build => [:restore] do |b|
	b.sln = 'src/HomePractice.sln'
	b.target = ['Clean', 'Rebuild', ] 
	b.prop 'Configuration', 'Release'
  # alt: b.file = 'src/MyProj.sln'
end