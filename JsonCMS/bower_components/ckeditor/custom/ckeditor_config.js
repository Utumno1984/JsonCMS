/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
	config.toolbarGroups = [
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
        { name: 'forms' },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'links' },
        { name: 'insert' },
        { name: 'others' },
        { name: 'about' },
        '/',
        { name: 'styles' },
        { name: 'colors' },
        { name: 'tools' },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] }
        
        //{ name: 'justify', justifyClasses: ['AlignLeft', 'AlignCenter', 'AlignRight', 'AlignJustify'] }
	];

	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	//config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
    //config.removeDialogTabs = 'image:advanced;link:advanced';

    config.extraPlugins = 'colorbutton,justify,image2,font';

    // Use the classes 'AlignLeft', 'AlignCenter', 'AlignRight', 'AlignJustify'
    //config.justifyClasses = ['AlignLeft', 'AlignCenter', 'AlignRight', 'AlignJustify'];

    //config.extraPlugins = 'image2';


    //CKEDITOR.config.imageUploadURL = <INSERT URL>;

    //CKEDITOR.config.dataParser: func(data);

};

//CKEDITOR.replace('news-body', {
//    extraPlugins: 'image2,uploadimage',

//    toolbar: [
//        { name: 'clipboard', items: ['Undo', 'Redo'] },
//        { name: 'styles', items: ['Styles', 'Format'] },
//        { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
//        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
//        { name: 'links', items: ['Link', 'Unlink'] },
//        { name: 'insert', items: ['Image', 'Table'] },
//        { name: 'tools', items: ['Maximize'] },
//        { name: 'editing', items: ['Scayt'] }
//    ],

//    // Configure your file manager integration. This example uses CKFinder 3 for PHP.
//    filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
//    filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
//    filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files',
//    filebrowserImageUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images',

//    // Upload dropped or pasted images to the CKFinder connector (note that the response type is set to JSON).
//    uploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files&responseType=json',

//    // Reduce the list of block elements listed in the Format drop-down to the most commonly used.
//    format_tags: 'p;h1;h2;h3;pre',
//    // Simplify the Image and Link dialog windows. The "Advanced" tab is not needed in most cases.
//    removeDialogTabs: 'image:advanced;link:advanced',

//    height: 450
//});